# junio14
junio14 entity framework, linq y operación lambda

# En el package management

```c#
Install-Package Microsoft.EntityFrameworkCore.Relational -Version 6.0.0-preview.4.21253.1
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.0-preview.4.21253.1
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.0-preview.4.21253.1
```

# En el package management, ejecutar el scaffold

```c#
Scaffold-DbContext "Data Source=(local)\sqlexpress;Initial Catalog=Sakila;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models 
```