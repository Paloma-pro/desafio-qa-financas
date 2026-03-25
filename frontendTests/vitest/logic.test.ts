import { expect, test, describe } from 'vitest';

const podeRegistrarReceita = (idade: number) => {
  return idade >= 18;
};

describe('Validações de Regra de Negócio', () => {

  test('Deve permitir receita para maiores de 18 anos', () => {
    expect(podeRegistrarReceita(20)).toBe(true);
  });

  test('NÃO deve permitir receita para menores de 18 anos', () => {
    expect(podeRegistrarReceita(15)).toBe(false);
  });
  
});