import {
  StockMovementPage,
  StockMovementReportPage,
  StockMovementDailyReportPage,
} from "./pages/stock";

const AppRoutes = [
  {
    index: true,
    path: '/',
    element: <StockMovementPage />
  },
  {
    index: true,
    path: '/report',
    element: <StockMovementReportPage />
  },
  {
    index: true,
    path: '/daily-report',
    element: <StockMovementDailyReportPage />
  }
];

export default AppRoutes;
