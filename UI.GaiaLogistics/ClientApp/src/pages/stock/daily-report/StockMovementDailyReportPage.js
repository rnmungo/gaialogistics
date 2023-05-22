import MuiBox from '@mui/material/Box';
import MuiTypography from '@mui/material/Typography';
import { DailyReportTableContainer } from '../../../containers/dailyReportTable';

const StockMovementDailyReportPage = () => (
  <>
    <MuiTypography component="h1" variant="h4">Informe Diario (Destinos con más de tres operaciones)</MuiTypography>
    <MuiBox sx={{ py: 4 }}>
      <DailyReportTableContainer />
    </MuiBox>
  </>
);

export default StockMovementDailyReportPage;
