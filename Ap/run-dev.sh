#!/bin/sh
# Author yozian
profile="dev"
project="App"

if [[ ! -z "$2" ]];then
   profile=$2
fi

mode=$1

case ${mode} in
    web)
        echo "*** start web service"
        ## start 
        (trap 'kill 0' SIGINT; 
          dotnet run --project ${project}.Web --launch-profile=${profile}
        )   
        ;;
    api)
        echo "*** start api service"
        ## start 
        (trap 'kill 0' SIGINT; 
          dotnet run --project ${project}.Api --launch-profile=${profile}
        )   
        ;;
    *)
        echo "*** start client/web/api services"
        ## start 
        (trap 'kill 0' SIGINT; 
          dotnet run --project ${project}.Web --launch-profile=${profile} \
        & dotnet run --project ${project}.Api --launch-profile=${profile} \
        )
            ;;
esac

