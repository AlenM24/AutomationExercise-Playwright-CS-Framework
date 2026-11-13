AutomationExercise — C# Playwright UI & API Automation Framework

An end-to-end test automation framework built with C# (.NET 8.0), Microsoft Playwright, NUnit, and GitHub Actions CI/CD targeting a multi-screen e-commerce web application and its REST API layer.

Key Architectural Highlights

• Modular Page Object Model (POM): Strictly decoupled screen and component classes (SignupPage, AccountCreatedPage, LoginPage, ProductPage, CartPage, and NavbarComponent) keeping locators and UI interactions separate from test assertions.
• Dynamic Session & Consent Handling: Automated GDPR cookie modal dismissal and timestamp-driven unique email generation (DateTime.UtcNow.Ticks) for repeatable end-to-end user registration runs.
• Data-Driven Testing ([TestCase]): Parameterized NUnit negative login matrices validating multiple invalid credential scenarios without duplicate code.
• REST API Integration Testing: Automated backend endpoint validation using Playwright's APIRequest context, covering both GET JSON parsing (System.Text.Json) and form-encoded POST search payloads (FormData).
• Continuous Integration (CI/CD): Automated headless regression pipeline configured via GitHub Actions (.github/workflows/playwright.yml) executing on every push to master.

Tech Stack

• Language & Runtime: C# / .NET 8.0
• UI & API Automation: Microsoft Playwright (Microsoft.Playwright.NUnit)
• Test Runner & Assertions: NUnit
• CI/CD: GitHub Actions (ubuntu-latest)

Implemented Test Coverage

• End-to-End User Registration (UI): Full multi-page signup flow, country selection, account confirmation, and navbar session verification.
• Product Search & Cart Validation (UI): Catalog search, modal cart navigation, and line-item price/quantity assertions.
• Negative Login Matrix (Data-Driven UI): Parameterized credential validation checking error state handling.
• Products & Search Endpoints (REST API): Automated GET /api/productsList and POST /api/searchProduct status and payload verification.
