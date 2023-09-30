#!/bin/sh
# Author yozian
project=$1
env=$2
platform=$3
packagePath=$4
commit=$(date +"%Y.%m.%d-%H:%M:%s")
if [ -x "$(command -v git)" ]; then
  commit=$(git rev-parse --short HEAD)
fi
mode='Release'

case ${env} in
prod)
  mode='Release'
  ;;
*)
  mode='Debug'
  ;;
esac

# rid : https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
case ${platform} in
win)
  echo "target to [Windows 10 / Windows Server 2016]"
  platform="win10-x64"
  ;;
win8)
  echo "target to [Windows 8.1 / Windows Server 2012 R2]"
  platform="win81-x64"
  ;;
linux)
  echo "target to [ubuntu.18.04-x64]"
  platform="ubuntu.18.04-x64"
  ;;
rhel)
  echo "target to [rhel-x64]"
  platform="rhel-x64"
  ;;
*)
  echo "default target to  [Windows 10 / Windows Server 2016]"
  platform="win10-x64"
  ;;
esac

echo "*** build with [${mode}] mode for platform: [${platform}]"

# clean publish

echo "clean publish folder"

rm -rf Publish/${platform}/${project}/*.dll
rm -rf Publish/${platform}/${project}/*.json
rm -rf Publish/${platform}/${project}/*.pdb
rm -rf Publish/${platform}/${project}/*.xml

# npm i
# bower install --allow-root && sleep 1
# gulp && sleep 1 && gulp minify && sleep 1
# cd -

# add commit hash
if [ -x "$(command -v git)" ]; then
  echo "commit: ${commit}"
  sed -i "s/$.hash/${commit}/i" App.Infrastructure/BuildVersion.cs
fi
# cat  ${project}/Version.cs
if [ ! -z "${packagePath}" ]; then

  dotnet restore -s "${packagePath}"
else
  dotnet restore
fi

dotnet publish ${project}/${project}.csproj \
  --force \
  -f net6.0 \
  -c ${mode} \
  -o Publish/${platform}/${project}/ \
  -r ${platform} \
  --self-contained false

echo ${commit} >Publish/${platform}/${project}/version.txt
#
#
#echo 'remove web.config from publish'

#rm -f Publish/${platform}/${project}/web.config

# recover the version file
if [ -x "$(command -v git)" ]; then
  git checkout App.Infrastructure/BuildVersion.cs
fi
# git checkout ${project}/${project}.csproj
