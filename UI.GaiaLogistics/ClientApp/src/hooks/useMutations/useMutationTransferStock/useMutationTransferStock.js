import { useMutation } from 'react-query';
import { coreRestClient } from '../../../utilities/RestClients';

const transferStock = ({ originId, destinationId, userId, items }) =>
  coreRestClient.post('/stock-movement/transfer', {
    originId,
    destinationId,
    userId,
    items,
  });

const useMutationTransferStock = () => {
  const { status, error, mutate, reset, data } = useMutation(transferStock);

  return {
    status,
    error,
    mutate,
    reset,
    data,
  };
};

export default useMutationTransferStock;
