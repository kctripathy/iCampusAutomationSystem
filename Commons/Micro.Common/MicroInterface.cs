
namespace Micro.Commons
{
    public interface MicroInterface
    {
        void FillGridView(string searchText="");
        bool ValidateFormFields();
        int InsertRecord();
        int UpdateRecord();
        int DeleteRecord();
    }
}
