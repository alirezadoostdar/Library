namespace Library.Infarstructure;

internal interface IUnitOfWork
{
    void Save();
    void Commit();
    void Begin();
    void Rollback();
}
