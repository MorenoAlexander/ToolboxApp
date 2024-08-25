pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:8.0'
    }
  }

  stage('Clone') {
    steps {
      git url: 'https://github.com/MorenoAlexander/ToolboxApp', branch: 'master'
    }
  }

  stage('build') {
    steps{
      ls -la
      dotnet build
    }
  }
  
}
