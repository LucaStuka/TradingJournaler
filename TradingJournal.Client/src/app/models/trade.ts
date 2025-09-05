export interface Trade {
  id: number;
  symbol: string;
  entryDate: string;
  exitDate?: string;
  quantity: number;
  entryPrice: number;
  exitPrice?: number;
  profitLoss?: number;
}
