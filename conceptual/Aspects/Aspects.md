# Creating Aspects

There are two APIs to create aspects:

- The **simplified API** allows you to override methods and accessors of properties, fields, and events.

- The **complete API** exposes all features:
  - override methods and accessors of properties, fields, and events;
  - introduce methods, fields, properties, events;
  - implement new interfaces into fields;
  - create aspects that are made of several of the transformations above

The simplified API is based on the complete API, so they are just helper classes that you could create yourself.

## Getting Started

@"overriding-methods"

@"overriding-fields-or-properties"

@"overriding-events"

## Understanding the framework design

@"templates"

@"aspect-framework-design"

## Creating advanced aspects

@"overriding-members"

@"introducing-members"

@"implementing-interfaces"