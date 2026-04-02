## **1️⃣ Run PostgreSQL in Docker**

Open a terminal and run:

```bash id="pgdocker1"
docker run --name my-postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Secret123 -e POSTGRES_DB=ProductDb -p 5432:5432 -d postgres:16
```

Explanation:

- `--name my-postgres` → container name
- `POSTGRES_USER=postgres` → username
- `POSTGRES_PASSWORD=Secret123` → password
- `POSTGRES_DB=ProductDb` → database name
- `-p 5432:5432` → maps local port to container port
- `postgres:16` → PostgreSQL image (latest version)

✅ Now PostgreSQL is running locally on port `5432`.

---

## **2️⃣ Install Npgsql EF Core provider**

In your ASP.NET Core project:

```bash id="nugetinstall"
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

This is required for PostgreSQL support in EF Core.

---

## **3️⃣ Update `Program.cs` to use PostgreSQL**

Replace the in-memory DB setup:

```csharp id="pgprogram"
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql("Host=localhost;Port=5432;Database=ProductDb;Username=postgres;Password=Secret123"));
```

Explanation of the connection string:

- `Host=localhost` → Docker maps the container to your machine
- `Port=5432` → default PostgreSQL port
- `Database=ProductDb` → the database you created
- `Username` and `Password` → match Docker env variables

---

## **4️⃣ Add EF Core migrations (optional but recommended)**

If you want EF Core to create tables:

```bash id="pgmigration1"
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

✅ This will create your `Products` table in PostgreSQL.

---

## **5️⃣ Test connection**

Run your app:

```bash id="pgrun1"
dotnet run
```

Then go to Swagger:

```
POST http://localhost:5252/api/Products
```

Try sending a product. It should be stored in PostgreSQL instead of in-memory.

---

## **6️⃣ Optional: Docker Compose for PostgreSQL + App**

Instead of running PostgreSQL manually, you can create `docker-compose.yml`:

```yaml id="pgcompose1"
version: "3.9"
services:
  postgres:
    image: postgres:16
    container_name: my-postgres
    environment:
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: Secret123
      POSTGRES_DB: ProductDb
    ports:
      - "5432:5432"
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
```

Then just:

```bash id="pgcomposeup"
docker-compose up -d
```

---

💡 **Tips:**

- If your app runs in Docker too, use `Host=postgres` (service name) instead of `localhost`.
- You can connect with pgAdmin or DBeaver using the same credentials.

---

I can also write a **ready-to-go `Program.cs` + `AppDbContext` setup for PostgreSQL** so you can just copy-paste and test with Docker.

Do you want me to do that?
