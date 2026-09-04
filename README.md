## **Управление БД**
### - Добавление миграции
```
dotnet ef migrations add AccessTickets --startup-project Maxanger.Api --project Maxanger.Infrastructure
```
### - Обновление БД
```
dotnet ef database update --startup-project Maxanger.Api --project Maxanger.Infrastructure
```