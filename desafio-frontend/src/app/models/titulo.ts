export interface Parcela {
  numeroParcela: number;
  dataVencimento: string;
  valor: number;
}

export interface Titulo {
  numeroTitulo: string;
  nomeDevedor: string;
  cpfDevedor: string;
  percentualJuros: number;
  percentualMulta: number;
  parcelas: Parcela[];
}