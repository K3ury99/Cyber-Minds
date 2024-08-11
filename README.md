# 🚀 Cyber-Minds
**Cyber-Minds** is a web application developed with ASP.NET MVC that connects to a C# web API and a SQL Server database. The system is designed to manage detailed information about clients, products, vendors, and branches, providing a comprehensive and efficient solution for data management.

<div style="display: flex;">
  <img src="https://github.com/user-attachments/assets/20924698-5290-4fe7-a5ae-041e02eb00d9" width="49%"></img>
  <img src="https://github.com/user-attachments/assets/bdd3ce65-ca9e-4b09-b324-634cab42d6bf" width="49%"></img>
</div>

## Explanatory video of the project
- **Link:** https://www.youtube.com/watch?v=eOjEbYPB4s0

## 🔗 Features
- **Technologies Used**:
  - **ASP.NET MVC**: Primary framework for web application development.
  - **C#**: Programming language used for the web API.
  - **SQL Server**: Database management system for storing and retrieving information.
  - **HTML/CSS/JavaScript**: Web technologies for user interface design and functionality.

## ♟ Project Structure
- **Main Folder**: `CyberMinds`
- **Key Subfolders and Files**:
  - `Controllers/` - Application controllers.
  - `Models/` - Data models and entity classes.
  - `Views/` - Application views for data presentation.
  - `Scripts/` - JavaScript files and libraries.
  - `Styles/` - CSS files for styling and design.
  - `.gitignore` - Configuration file for ignoring unwanted files in Git.
  - `LICENSE` - Project license file.
  - `README.md` - Document with project information.

## 🏆 Database configuration

1. Make sure you have SQLserver installed on your system.

2. Open the `appsettings.json` file and check the database connection string. Make sure it is pointing correctly to the SQLserver database file.

3. Run the migrations to create the database:
    ```bash
    add-migration init
    ```
3. Send the update of the tables to the database:
    ```bash
    update-database
    ```
## 🐱‍👤 Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/K3ury99/Cyber-Minds.git
    ```
2. Navigate to the project folder:
    ```bash
    cd Cyber-Minds/CyberMinds
    ```
3. Open the project in Visual Studio or your preferred IDE.
4. Restore project dependencies and set up the database.
5. Configure the `appsettings.json` file with your SQL Server connection details.
6. Run the application and verify that it deploys correctly in your local environment.

## 💎 Contributions
Contributions are welcome. If you wish to contribute to the project, please follow these steps:
1. Fork the repository.
2. Create a branch for your feature or bug fix (`git checkout -b feature/new-feature`).
3. Make your changes and commit (`git commit -am 'Add new feature'`).
4. Push your branch (`git push origin feature/new-feature`).
5. Open a pull request on GitHub.

## 📔 License
This project is licensed under the [MIT License](./LICENSE).

## Credits 🎉

This project was developed by: **Keury Ramírez, Victor Sanchez**.
