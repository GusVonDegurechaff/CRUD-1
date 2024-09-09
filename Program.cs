// Добавление
using CRUD__1;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("Введите кол-во добавляемых пользователей");
    int z = int.Parse(Console.ReadLine());
    for (int x = 0; x < z; x++)
    {
        Console.WriteLine("Как зовут пользователя?");
        string Name = Console.ReadLine();
        Console.WriteLine("Возраст пользователя?");
        int Age = Convert.ToInt32(Console.ReadLine());

        User user = new User(Name, Age);

        db.Users.Add(user);
        db.SaveChanges();
        Console.WriteLine("Объект успешно сохранен");
    }
    Console.WriteLine("Список объектов:");
    foreach (User u in db.Users.ToList())
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }

}

using (ApplicationContext db = new ApplicationContext())
{
    // получаем ID пользователя для редактирования
    Console.WriteLine("Введите ID пользователя для редактирования:");
    int userIdToEdit = int.Parse(Console.ReadLine());

    // находим пользователя по ID
    User userToEdit = db.Users.FirstOrDefault(u => u.Id == userIdToEdit);

    if (userToEdit != null)
    {
        // редактируем данные пользователя
        Console.WriteLine("Введите новое имя:");
        userToEdit.Name = Console.ReadLine();

        Console.WriteLine("Введите новый возраст:");
        userToEdit.Age = int.Parse(Console.ReadLine());

        // обновляем пользователя в базе данных
        db.Users.Update(userToEdit);
        db.SaveChanges();
        Console.WriteLine($"Пользователь с ID {userIdToEdit} успешно отредактирован.");
    }
    else
    {
        Console.WriteLine($"Пользователь с ID {userIdToEdit} не найден.");
    }

    // выводим список пользователей после редактирования
    Console.WriteLine("\nСписок пользователей после редактирования:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Удаление
using (ApplicationContext db = new ApplicationContext())
{
    // получаем ID пользователя для удаления
    Console.WriteLine("Введите ID пользователя для удаления:");
    int userIdToDelete = int.Parse(Console.ReadLine());

    // находим пользователя по ID
    User userToDelete = db.Users.FirstOrDefault(u => u.Id == userIdToDelete);

    if (userToDelete != null)
    {
        // удаляем пользователя из базы данных
        db.Users.Remove(userToDelete);
        db.SaveChanges();
        Console.WriteLine($"Пользователь с ID {userIdToDelete} удален.");
    }
    else
    {
        Console.WriteLine($"Пользователь с ID {userIdToDelete} не найден.");
    }

    // выводим список пользователей после удаления
    Console.WriteLine("\nСписок пользователей после удаления:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
