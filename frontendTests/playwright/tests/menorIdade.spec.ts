import { test, expect } from '@playwright/test';

test('Deve impedir registro de receita para menores de idade', async ({ page }) => {

    await page.goto('http://localhost:5173');

    await page.locator('ul').getByRole('link', { name: 'Transações' }).click();

    const botaoAdicionar = page.getByRole('button', { name: 'Adicionar Transação' });
    await botaoAdicionar.waitFor({ state: 'visible'});
    await botaoAdicionar.click();

    await page.getByLabel('Pessoa').click();
    await page.getByText('Carlos Almeida').click();

    const aviso = page.locator('text=Menores só podem registrar despesas.');
    await expect(aviso).toBeVisible();

});