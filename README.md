## lab15api

Демонстраційний REST API для лабораторної роботи 15 (.NET MAUI).

### Маршрути

| Маршрут | HTTP-код | Опис |
|---|---|---|
| `/api/products` | 200 | Каталог з 4 рослинами |
| `/api/empty` | 200 | Порожній масив |
| `/api/error` | 503 | Service Unavailable |
| `/api/invalid` | 200 | Некоректний JSON |
| `/api/slow` | 200 | Затримка 15 сек (тест таймауту) |

### Локальний запуск

```bash
dotnet run
```

Сервер запуститься на `http://0.0.0.0:5185`.

### Розгортання на Render.com

1. Зайдіть на [render.com](https://render.com)
2. Створіть **Web Service** → **Connect Repository** → оберіть `lab15api`
3. Build Command: `docker build -t app .`
4. Start Command: `docker run -p 8080 app`
5. Або використайте Dockerfile автоматично (Render підтримує Docker)
