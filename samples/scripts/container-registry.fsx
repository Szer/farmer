#r @"./libs/Newtonsoft.Json.dll"
#r @"../../src/Farmer/bin/Debug/netstandard2.0/Farmer.dll"

open Farmer
open Farmer.Resources.ContainerRegistry

let myRegistry = containerRegistry {
    name "devonRegistry"
    sku Basic
    enable_admin_user
}

let deployment = arm {
    location NorthEurope
    add_resource myRegistry
    output "registry" myRegistry.Name
    output "loginServer" myRegistry.LoginServer
}

deployment
|> Deploy.execute "FarmerTest" Deploy.NoParameters