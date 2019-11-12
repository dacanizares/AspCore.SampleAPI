# Sample API

[![Build status](https://ci.appveyor.com/api/projects/status/ur4xs9mt3s3q3big?svg=true)](https://ci.appveyor.com/project/dacanizares/aspcore-sampleapi)

This is an example ASP Core project that tries to show how to create a simple project balancing an agile coding within a structured solution, avoiding unnecessary complexity.

## Instructions to RUN locally.

* Open Solution.

* Execute migrations (From the Package Manager Console type: *update-database*).

* Run!

## Project structure

* **SampleApi.Domain**:
  * **Behaviors**: Business logic.
  * **Infrastructure**: Repository contracts.
  * **Models**: Domain models.

* **SampleApi**:
  * **Commands**: Actions that can be executed by the controllers.
  * **Controllers**: They contain mappings and calls to behaviors or queries to execute the requested action. If you prefer, you can move mappings to the behaviors class (or a new intermediate component) to make your controllers *completely dump*, both options are still valid. ;)
  * **Infrastructure**:  Application DbContext and repositories implementations.
  * **Mappings**: AutoMapper profiles.
  * **Migrations**: EF Core migrations and Data Seeds.
  * **Queries**: Data retrieval components.
  * **ViewModels**: Models to display info in the UI.
  
## More information

* Do you want to go deeper? [Try this approach using Vortex](https://github.com/equilaterus/VortexSamples.ConcurrentOrdering).

* Check [our wiki](https://equilaterus.github.io/wikilaterus/)
