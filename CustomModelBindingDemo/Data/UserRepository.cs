namespace CustomModelBindingDemo.Data
{
    public interface UserRepository
    {
        User Retrieve(string email);

        void Update(User user);
    }
}
