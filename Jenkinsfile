node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'dotnet restore SuperMetroidRandomizer.sln'
		bat 'dotnet build SuperMetroidRandomizer.sln -c Release'
}