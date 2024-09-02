pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:8.0'

    }
  }

  environment {
    HOME = '/tmp'
    TEST='yes'
  }

  stages {
    stage('Clone') {
      steps {
        git url: 'https://github.com/MorenoAlexander/ToolboxApp', branch: 'master'
      }
    }
    stage('build') {
      steps{
        sh 'ls -la'
        sh 'dotnet build'
      }
    }
  }
}
