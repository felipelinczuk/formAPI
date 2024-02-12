#!/bin/bash

dotnet ef database update

cd ./bin/Release/net8.0/

dotnet formAPI.dll