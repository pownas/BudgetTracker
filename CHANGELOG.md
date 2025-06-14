# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased] - 2025-06-14

### Added
- Created BudgetTracker.Services.LocalHost project in the Blazor folder structure
- Added IApiService interface and ApiService implementation
- Added database-creation.sql to the BudgetTracker.Blazor directory

### Changed
- Consolidated project structure by moving components from src/ folder to BudgetTracker.Blazor
- Updated namespaces in ApiService and IApiService to reference BudgetTracker.Shared models
- Updated solution file to include the new BudgetTracker.Services.LocalHost project
- Downgraded all projects from .NET 9 to .NET 8 for better compatibility
- Updated all package references to use .NET 8 compatible versions (8.0.3)
- Simplified AppHost project by removing direct Aspire SDK reference
- Flattened project structure by moving all projects one level up in the file tree
- Renamed main projects from BudgetTracker.Blazor to BudgetTracker and BudgetTracker.Client

### Removed
- Eliminated redundant src/ folder after migrating all necessary files
- Removed references to BudgetTracker.Core (replaced with BudgetTracker.Shared)

### Technical Debt
- Consider adding unit tests for ApiService
- Review and update any remaining references to old project structure
