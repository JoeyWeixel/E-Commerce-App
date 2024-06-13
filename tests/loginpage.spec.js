import { test, expect } from '@playwright/test';

// URL of your local development server
const baseURL = 'http://localhost:5173/customers'; 

test.describe('loginPage Tests', () => {
  
    test('test basic button visibility', async ({ page }) => {
        await page.goto(baseURL);
        await expect(page.getByRole('link', { name: 'Website Logo' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Orders' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Login' })).toBeVisible();
        await expect(page.getByText('Cart')).toBeVisible();
        await expect(page.getByRole('button', { name: 'Sign Up' })).toBeVisible();
        await expect(page.getByText('Select User')).toBeVisible();
    });

    test('test sign in drop down appears', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'The real henry fritz Gavin' }).click();
        await expect(page.getByRole('button', { name: 'Sign In' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Delete' })).toBeVisible();
        await expect(page.getByText('Email: Gavin.Weixel@neudesic.')).toBeVisible();
        await expect(page.getByText('Phone:')).toBeVisible();
        await expect(page.getByText('Address: 250 S High St')).toBeVisible();
    });

    test('test "sign up" modal appears upon click', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'Sign Up' }).click();
        await expect(page.getByRole('heading', { name: 'Sign Up' })).toBeVisible();
        await expect(page.getByRole('button', { name: 'Create Account' })).toBeVisible();
        await expect(page.getByText('Name', { exact: true })).toBeVisible();
        await expect(page.getByText('Email')).toBeVisible();
        await expect(page.getByText('Address')).toBeVisible();
        await expect(page.getByText('Phone')).toBeVisible();
        await expect(page.getByLabel('Sign Up')).toBeVisible();
    });

    test('test #1 login functionality', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'The real henry fritz Gavin' }).click();
        await page.getByRole('button', { name: 'Sign In' }).click();
        await expect(page.locator('span').filter({ hasText: 'Gavin Weixel' })).toBeVisible();
    });

    test('test #2 login functionality ', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'The real henry fritz Joey' }).click();
        await page.getByRole('button', { name: 'Sign In' }).click();
        await expect(page.locator('span').filter({ hasText: 'Joey Weixel' })).toBeVisible();
    });

    test('test to assure that user stays logged in as they return to homepage', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'The real henry fritz Gavin' }).click();
        await page.getByRole('button', { name: 'Sign In' }).click();
        await page.getByRole('link', { name: 'Website Logo' }).click();
        await expect(page.getByText('Gavin Weixel')).toBeVisible();
    });

    test('test account creation', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'Sign Up' }).click();
        await page.getByPlaceholder('Name').fill('Joe Smoe');
        await page.getByPlaceholder('Email').click();
        await page.getByPlaceholder('Email').fill('joe@gmail.com');
        await page.getByPlaceholder('Address').click();
        await page.getByPlaceholder('Address').fill('test address 123 st');
        await page.getByPlaceholder('(000) 000-').click();
        await page.getByPlaceholder('(000) 000-').fill('1231231234');
        await page.getByRole('button', { name: 'Create Account' }).click();
        await page.getByRole('button', { name: 'Close' }).click();
        await expect(page.getByRole('button', { name: 'The real henry fritz Joe Smoe' })).toBeDefined();
    });

    test('test account deletion', async ({ page }) => {
        await page.goto(baseURL);
        await page.getByRole('button', { name: 'The real henry fritz Joe Smoe' }).click();
        await page.getByRole('button', { name: 'Delete' }).click();
        
        // TODO - Add a check to see if the account was deleted (Ask someone how to do this)
    });
});
