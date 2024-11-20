# How to Manage Features in .NET and C# with Azure App Configuration: Centralized Feature Flags and Settings

This repository contains the source code for a tutorial series on how to manage features in .NET and C# applications using **Azure App Configuration**. The project walks through the basics of **Feature Flags**, **A/B Testing**, and how to manage these features remotely without the need to redeploy your applications. It shows how to leverage **Azure App Configuration** to control and toggle features in your application, enabling a more dynamic and flexible development process.

### Usage Instructions
- The **main branch** contains the base solution, which demonstrates a simple **Feature Flag** setup without Azure App Configuration.
- The **app-configuration branch** extends the basic solution to incorporate **Azure App Configuration** for managing feature flags and settings centrally.

### Features in the Project:
- **Feature Flags Implementation:** Learn how to use feature flags in .NET to toggle new features like detailed weather reports in a weather API.
- **Azure App Configuration:** Explore how to integrate **Azure App Configuration** into your .NET application, allowing centralized management of feature flags and application settings.
- **Real-time Configuration Changes:** Demonstrate how you can change feature flag values in real-time without redeploying the application.
- **A/B Testing Setup:** Implement simple A/B testing by toggling different features based on user conditions.

---

## Contents

- **Project Description**  
- **How to Run the Project**  
- **Links to Tutorials**  
- **Contributions**  
- **License**

---

### Project Description
This repository is a hands-on tutorial showing how to manage feature flags and settings in **.NET and C#** using **Azure App Configuration**. 

In this project, we go over:
- **Setting up Feature Flags:** We'll start by using simple feature flags to toggle between two types of data display (detailed vs. basic data) in a .NET Minimal API.
- **Azure App Configuration Integration:** We then extend the solution to use **Azure App Configuration** for managing the feature flags externally and enable seamless toggling of features via Azure.
- **Real-time Changes:** We'll explore how to dynamically change features or configurations remotely using Azure App Configuration without requiring code changes or redeploying.
- **A/B Testing:** The project also includes an example of basic A/B testing by directing a certain percentage of users to a new feature via feature flags.

### How to Run the Project
To run the project locally, follow these steps:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ottorinobruni/WeatherApiWithFeatureFlags.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd WeatherApiWithFeatureFlags
   ```

3. **Restore the dependencies:**
   ```bash
   dotnet restore
   ```

4. **Build the project:**
   ```bash
   dotnet build
   ```

5. **Run the project:**
   ```bash
   dotnet run
   ```

6. **For the `app-configuration` branch:**
   - Before running the project, ensure you have an **Azure App Configuration** instance set up in your Azure portal.
   - Follow the instructions in the `app-configuration` branch for integrating **Azure App Configuration** and managing your feature flags through Azure.

### Links to Tutorials
For more in-depth information, check out the following tutorials on my blog:

- [How to Turn On Features in .NET and C# Without Redeploying: Exploring Feature Flags and A/B Testing](https://www.ottorinobruni.com/how-to-turn-on-features-in-dotnet-and-csharp-without-redeploying-exploring-feature-flags-and-ab-testing/)
- [How to Use Azure App Configuration to Manage Feature Flags in .NET](#) (upcoming blog post on this project)

### Contributions
Contributions are welcome! If you'd like to improve this project or fix issues, feel free to open a pull request or report an issue.

### License
This project is licensed under the MIT License. See the LICENSE file for details.

---

### Example Scenario

In the `app-configuration` branch, the **weather API** uses the `DetailedWeatherForecast` feature flag to toggle between showing detailed or basic weather information. By changing the value of the feature flag in **Azure App Configuration**, you can dynamically control which version of the forecast data is shown to the users, without the need to redeploy the application.

---

This structure helps you organize the repository and clarify the differences between the base solution and the extended solution with **Azure App Configuration**.
