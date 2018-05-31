# Changelog
Because I often forget to push changes to Github, changes between versions will be tracked in this changelog file.

Mang adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.2] - 2018-05-31
### Added
- A new RandomNumber class was added to provide "better" random number generation in Markov chain use
- Most UI controls are now data-bound to their backing properties

### Changed
- Most of the code has been refactored in some way to make it more legible
- Code comments have been added to display code intent more clearly
- Exceptions should be output to a MessageBox now, instead of to the Markov Output List

### Removed
- RootDirPicker has been removed completely.
- GlobalProperties, and all references to the fields within, have been removed.
- Unused / unreachable code has been removed