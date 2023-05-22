import MuiBox from '@mui/material/Box';
import MuiPaper from '@mui/material/Paper';
import MuiTable from '@mui/material/Table';
import MuiTableBody from '@mui/material/TableBody';
import MuiTableCell from '@mui/material/TableCell';
import MuiTableContainer from '@mui/material/TableContainer';
import MuiTableHead from '@mui/material/TableHead';
import MuiTableRow from '@mui/material/TableRow';
import { ReportTableRow } from './reportTableRow';
import { Spinner } from '../../components/spinner';
import { useQueryDailyReport } from '../../hooks/useQueries';

const DailyReportTableContainer = () => {
  const { data, status, error } = useQueryDailyReport();

  return (
    <>
      <Spinner loading={['loading', 'refetching'].includes(status)} label="Cargando datos..." />
      {status === 'error' && <div>{error.message}</div>}
      {status === 'success' && data && (
        <MuiBox sx={{ my: 2 }}>
          <MuiTableContainer component={MuiPaper}>
            <MuiTable aria-label="collapsible table">
              <MuiTableHead>
                <MuiTableRow>
                  <MuiTableCell />
                  <MuiTableCell align="left">Origen</MuiTableCell>
                  <MuiTableCell align="left">Destino</MuiTableCell>
                  <MuiTableCell align="left">Responsable</MuiTableCell>
                  <MuiTableCell align="left">Fecha</MuiTableCell>
                </MuiTableRow>
              </MuiTableHead>
              <MuiTableBody>
                {data.length > 0 && data.map(row => (
                  <ReportTableRow key={row.id} row={row} />
                ))}
                {data.length === 0 && (
                  <MuiTableRow>
                    <MuiTableCell component="th" scope="row" align="center" colSpan={5}>
                      No hay datos para mostrar
                    </MuiTableCell>
                  </MuiTableRow>
                )}
              </MuiTableBody>
            </MuiTable>
          </MuiTableContainer>
        </MuiBox>
      )}
    </>
  );
};

export default DailyReportTableContainer;
