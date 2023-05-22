import MuiBox from '@mui/material/Box';
import MuiTypography from '@mui/material/Typography';
import { ReportTableContainer } from '../../../containers/reportTable';

const StockMovementReportPage = () => (
  <>
    <MuiTypography component="h1" variant="h4">Informe de Operaciones</MuiTypography>
    <MuiBox sx={{ py: 4 }}>
      <ReportTableContainer />
    </MuiBox>
  </>
);

export default StockMovementReportPage;
