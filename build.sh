#!/bin/sh
dotnet restore --verbosity minimal || exit 1
dotnet build src/ProjectEuler || exit 1
dotnet test tests/ProjectEuler.Tests || exit 1
