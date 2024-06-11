import { test, expect } from '@playwright/test';

// URL of your local development server
const baseURL = 'http://localhost:5173\cart'; 

test.describe('HomePage Tests', () => {
    test('test basic button visability', async ({ page }) => {
        await page.goto('http://localhost:5173/cart');
        await expect(page.getByRole('link', { name: 'Website Logo' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Orders' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Login' })).toBeVisible();
        await expect(page.getByText('Cart', { exact: true })).toBeVisible();
        await expect(page.getByRole('link', { name: 'Go Shopping' })).toBeVisible();
        await expect(page.getByText('Shopping Cart')).toBeVisible();
    });


});
