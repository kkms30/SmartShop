using SmartShopWpf.Data;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    public class TransactionFinalizationInvoker
    {
        public void FinalizeCurrentTransaction()
        {
            Task finalize = Task.Factory.StartNew(() => { new TransactionManager().FinalizeTransaction(); });

            finalize.Wait();

            DataHandler.GetInstance().ClearTransaction();
        }
    }
}