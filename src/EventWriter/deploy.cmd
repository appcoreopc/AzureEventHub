

export rgname="testapprg"
export location="australiaeast"
export ehnamespace="testehnstempdata"

export ehname="ehtesttargetapp"

az group create --name $rgname --location $location 

az eventhubs namespace create --name $ehnamespace --resource-group $rgname -l $location


az eventhubs eventhub create --name $ehname --resource-group $rgname --namespace-name <Event Hubs namespace>
