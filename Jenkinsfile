node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore SuperMetroidRandomizer.sln'
		bat "\"${tool 'MSBuild'}\" SuperMetroidRandomizer.sln /p:Configuration=Release"
}