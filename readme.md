# UTM Builder

A type-safe .NET library for building and parsing UTM (Urchin Tracking Module) parameters for marketing campaign tracking.

## Overview

UTM Builder is a lightweight, fluent library that helps you create and manage UTM parameters in your URLs. Built with Domain-Driven Design principles, it provides type-safe value objects to ensure data integrity when tracking marketing campaigns across various channels.

## Features

- **Type-Safe**: Strongly-typed value objects prevent invalid UTM parameters
- **Fluent API**: Easy-to-use, intuitive interface for building UTM URLs
- **Bidirectional Conversion**: Convert between `Utm` objects and strings seamlessly
- **URL Validation**: Built-in validation for URLs and campaign parameters
- **Immutable Design**: Thread-safe, immutable value objects following DDD principles
- **.NET 9.0**: Built on the latest .NET platform

## Getting Started

### Installation

Clone the repository and reference the project in your solution:

```bash
git clone https://github.com/yourusername/UtmBuilder.git
```

Then add a project reference:

```bash
dotnet add reference path/to/UtmBuilder.Core/UtmBuilder.Core.csproj
```

### Basic Usage

#### Creating a UTM URL

```csharp
using UtmBuilder.Core.Entities;
using UtmBuilder.Core.ValueObjects;

// Create a URL and campaign
var url = new Url("https://example.com/");
var campaign = new Campaign(
    source: "google",
    medium: "cpc",
    name: "black_friday_sale"
);

// Build UTM
var utm = new Utm(url, campaign);
Console.WriteLine(utm);
// Output: https://example.com/?utm_source=google&utm_medium=cpc&utm_campaign=black_friday_sale
```

#### Creating a UTM with All Parameters

```csharp
var campaign = new Campaign(
    source: "newsletter",
    medium: "email",
    name: "spring_promotion",
    id: "123",
    term: "running shoes",
    content: "header_link"
);

var utm = new Utm(new Url("https://mystore.com/products"), campaign);
```

#### Parsing a UTM URL

```csharp
// Implicit conversion from string
Utm utm = "https://example.com/?utm_source=facebook&utm_medium=social&utm_campaign=launch";

// Access campaign properties
Console.WriteLine(utm.Campaign.Source);   // facebook
Console.WriteLine(utm.Campaign.Medium);   // social
Console.WriteLine(utm.Campaign.Name);     // launch
```

## Campaign Parameters

| Parameter   | Required | Description                     | Example                            |
| ----------- | -------- | ------------------------------- | ---------------------------------- |
| **Source**  | ✅       | Identifies the traffic source   | `google`, `newsletter`, `facebook` |
| **Medium**  | ✅       | Identifies the marketing medium | `cpc`, `email`, `social`, `banner` |
| **Name**    | ✅       | Identifies the campaign name    | `black_friday`, `spring_sale`      |
| **Id**      | ❌       | Identifies the campaign ID      | `abc123`                           |
| **Term**    | ❌       | Identifies paid search keywords | `running+shoes`                    |
| **Content** | ❌       | Differentiates similar content  | `logolink`, `textlink`             |

## Architecture

The library follows Domain-Driven Design principles with:

- **Entities**: `Utm` - Aggregates URL and Campaign
- **Value Objects**: `Url`, `Campaign` - Immutable, validated data objects
- **Exceptions**: Custom exceptions for invalid URLs and campaigns
- **Extensions**: Helper methods for list operations

## Testing

The project includes comprehensive unit tests using xUnit:

```bash
dotnet test
```

## License

This project is open source and available under the MIT License.
