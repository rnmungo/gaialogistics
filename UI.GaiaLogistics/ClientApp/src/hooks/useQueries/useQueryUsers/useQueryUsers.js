import { useQuery } from 'react-query';
import { coreRestClient } from '../../../utilities/RestClients';

const getUsers = async () => {
  const response = await coreRestClient.get('/user');
  return response.data;
};

const useQueryUsers = () => {
  const { status, data, refetch, error } = useQuery(
    ['users'],
    () => getUsers(),
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

export default useQueryUsers;
