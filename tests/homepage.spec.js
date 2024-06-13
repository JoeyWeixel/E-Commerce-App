import { test, expect } from '@playwright/test';

// URL of your local development server
const baseURL = 'http://localhost:5173'; 

test.describe('HomePage Tests', () => {
  
    test('test basic button visability', async ({ page }) => {
        await page.goto(baseURL);
        await expect(page.getByText('Our Products')).toBeVisible();
        await expect(page.getByRole('button', { name: 'Orders' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Login' })).toBeVisible();
        await expect(page.getByText('Cart', { exact: true })).toBeVisible();
        await expect(page.getByRole('button', { name: 'List Your Product' })).toBeVisible();
        await expect(page.getByRole('link', { name: 'Website Logo' })).toBeVisible();
    });

    test('test login button click', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'Login' }).click();
        await expect(page.url()).toBe(`${baseURL}/customers`);
    });

    test('test "Create Listing" modal popup', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'List Your Product' }).click();
        await expect(page.getByLabel('List your product')).toBeVisible();
        await page.getByRole('button', { name: 'Create Listing' }).click();
    });
    
});
