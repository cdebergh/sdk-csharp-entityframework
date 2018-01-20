
# Synopsis

This is a simple example CRUD ASP.NET Core 2.0 rest service using entity framework. It is based on https://github.com/chsakell/dotnetcore-entityframework-api

## Required Base Feature Support

1. Registration
Instruction in Jenkinsfile or equivalent to register this service for visibility
2. Instrumentation
Prometheus or equivalent to make the service operation visible
3. Logging
Nlog or equivalent
4. Documentation
README
5. Unit Testing
XUnit or equivalent
6. Static Code Analysis
7. Code Formatting
EasyConfig or equivalent


# Code Example

Fetch the contents of the service by issuing an HTTP GET on the /api/examples endpoint.

```
curl -X GET --header 'Accept: application/json' 'http://localhost:5000/api/examples'
```

Create an example object by issuing an HTTP POST on the /api/examples endpoint.

```
curl -X POST --header 'Content-Type: application/json-patch+json' --header 'Accept: application/json' -d '{ \ 
   "id": 0, \ 
   "name": "string" \ 
 }' 'http://localhost:5000/api/examples'
```

# Motivation

This is a basis to start forming the full basic CRUD service. It will then be abstracted and templated for quick generation of domain services.

# Installation

```
git clone https://github.com/cdebergh/sdk-csharp-entityframework
```

## Build

```dotnet build```

## Run

```dotnet run```

# API Reference

It's late, I'll fill this in later.

## Example

I said IT'S LATE I'LL FILL THIS IN LATER.

# Tests

```dotnet test```

# Contributors

Me: @cdebergh

# Additional Links

Provide a list of additional links that may be used to drill down deeper.

1. [Example .NET Core 1.0 CRUD service with entity framework](https://github.com/chsakell/dotnetcore-entityframework-api)