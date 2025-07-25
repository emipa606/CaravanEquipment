# .github/copilot-instructions.md

## Mod Overview and Purpose

**Caravan Equipment Mod** for RimWorld is designed to enhance the gameplay experience by improving how equipment is managed in caravans. It adds new systems and interaction layers to make caravan management more intuitive and strategic, especially during long journeys across the world map.

## Key Features and Systems

- **Equipment Management Interface**: A user-friendly interface to manage caravan equipment, allowing players to better organize and equip their caravans.
- **Settings Integration**: Adjustable settings to tailor equipment management to player preferences.
- **Dynamic Table Handling**: A dynamic table system to handle rows and columns, facilitating complex data management.
- **Utility Methods**: Helpful utility functions to support core functions and extend mod features.

## Coding Patterns and Conventions

1. **Class and Method Naming**: Class names use PascalCase while methods use PascalCase and are descriptive of their function.
2. **Encapsulation**: Most classes encapsulate their fields and expose functionality through public methods.
3. **Comment Usage**: Methods and important logic sections are well-commented to ease understanding and future modification.
4. **Single Responsibility Principle**: Classes are designed to have a single functionality or purpose, reducing complexity.

## XML Integration

While XML specifics are not included in this summary, it is critical for configuring item and pawn overrides. Ensure XML def files for items and settings are structured correctly to integrate seamlessly with the C# code.

## Harmony Patching

The mod does not explicitly list Harmony patches in this summary, but using Harmony is recommended for:
- Modifying or extending existing game methods safely.
- Ensuring compatibility with other mods by avoiding direct code modifications.

Whenever adding or modifying game logic:
- Use Harmony prefixes/postfixes instead of directly editing methods.
- Ensure patches are reversible and maintain game stability.

## Suggestions for Copilot

1. **Code Completeness**: Assist in completing methods that deal with settings exposure and table operations, particularly in `CaravanEquipmentSetting` and `TableData`.
2. **Error Handling**: Propose adding error-handling logic in methods that involve complex calculations or data operations.
3. **XML and C# Linking**: Suggest best practices for linking XML definitions with C# classes, ensuring data consistency.
4. **Performance Optimization**: Provide suggestions for optimizing table update methods and reducing lag during data refresh.
5. **Debugging Helpers**: Automatically include methods for logging debug data and drawing debug information for interface elements.

By following these instructions, developers can maintain a clear and consistent mod structure that improves functionality while remaining user-friendly and accessible for future modifications.
