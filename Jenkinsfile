pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:8.0'
    }
  }

  stages('Clone') {
    steps {
      git url: 'https://github.com/MorenoAlexander/ToolboxApp', branch: 'master'
    }
  }

  stages('build') {
    steps{
      ls -la
      dotnet build
    }
  }
}
