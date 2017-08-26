pipeline {
    agent { label 'root'}

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                git branch: 'origin', credentialsId: 'f9b33ec5-ca0c-4bfa-80db-4b6fc2fd2adf', url: 'https://github.com/CluboidLtd/Saas-portal.git'
                
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
