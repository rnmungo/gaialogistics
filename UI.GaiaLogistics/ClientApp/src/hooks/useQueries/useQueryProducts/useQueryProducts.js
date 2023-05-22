import { useQuery } from 'react-query';
import { coreRestClient } from '../../../utilities/RestClients';

const getProducts = async () => {
  const response = await coreRestClient.get('/product');
  return response.data;
};

const useQueryProducts = () => {
  const { status, data, refetch, error } = useQuery(
    ['products'],
    () => getProducts(),
    {
      enabled: true,
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

export default useQueryProducts;
