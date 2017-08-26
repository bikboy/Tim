pipeline {
    agent { label 'root'}

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                git branch: 'tima.biz.ua', credentialsId: 'bda0291c-1df9-4741-bee2-b472c054c3ed', url: 'https://github.com/bikboy/Tim.git'
                
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
                sh '''rm -rf /tima.biz.ua/data/*
                      cp -r * /tima.biz.ua/data
                '''
            }
        }
    }
}
