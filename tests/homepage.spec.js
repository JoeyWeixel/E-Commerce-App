import { test, expect } from '@playwright/test';

const baseURL = 'http://localhost:5173'; // Adjust this to match your local development server URL

test.describe('HomePage Tests', () => {
  
  test('Test', async ({ page }) => {
    await page.goto(baseURL);
    await expect(page.locator('text=Our Products')).toBeVisible();
  });

  test('opens product listing form', async ({ page }) => {
    await page.goto(baseURL);
    await page.click('button:has-text("List Your Product")');
    await expect(page.locator('text=Create Listing')).toBeVisible();
  });

  test('submits product listing form', async ({ page }) => {
    await page.goto(baseURL);
    await page.click('button:has-text("List Your Product")');
    await expect(page.locator('text=Create Listing')).toBeVisible();

    await page.fill('input[placeholder="Name"]', 'Test Product');
    await page.fill('input[placeholder="Description"]', 'This is a test product');
    await page.fill('input[type="number"][name="price"]', '20');
    await page.fill('input[type="number"][name="quantity"]', '5');

    await page.click('button[type="submit"]');
  });

});
