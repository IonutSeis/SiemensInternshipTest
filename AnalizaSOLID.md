1.
SOLID Principle violated: Dependency Inversion Principle
Location: Program.cs
Reason: Controllers depend on abstractions, but the framework hasn't been told which implementation to provide.
Fix: Added builder.Services.AddScoped<IItemReader, ItemRepository>(); to Program.cs

2.
SOLID Principle violated: Single Responsibility Principle
Location: ItemController.cs, Method: GetAll()
Reason: The controlled has too many reasons to change. It is responsible for handling HTTP requests and also for retrieving data from the repository.
Fix: Refactored the method to delegate data retrieval to a separate service.

3.
SOLID Principle violated: Open/Closed Principle
Location: ItemRepository.cs
Reason: The repository is not open for extension. If we want to add new data retrieval methods, we would have to modify the existing code.
Fix: Create a new implementation of the repository that fetches data from the external URL provided.

4.
SOLID Principle violated: Interface Segregation Principle / Naming
Location: IItemReader.cs, ItemRepository.cs, Item.cs
Reason: It violates the principle of "Least Astonishment" by having a method that returns a list of items, which may not be necessary for all implementations of the interface.
Fix: Rename Item to Grade, ItemRepository to GradeRepository, and IItemReader to IGradeReader to better reflect their purpose and avoid confusion.