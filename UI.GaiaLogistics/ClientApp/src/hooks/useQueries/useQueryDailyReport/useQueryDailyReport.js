import { useQuery } from 'react-query';
import { coreRestClient } from '../../../utilities/RestClients';

const getDailyReport = async () => {
  const response = await coreRestClient.get('/stock-movement/reports/min-three-operations');
  return response.data;
};

const useQueryDailyReport = () => {
  const { status, data, refetch, error } = useQuery(
    ['daily-report'],
    () => getDailyReport(),
    {
      enabled: true,
      staleTime: 60000,
      refetchOnWindowFocus: false,
    }
  );

  return {
    status,
    data,
    refetch,
    error,
  };
};

export default useQueryDailyReport;
