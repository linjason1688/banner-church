#!/bin/bash
# author: yozian
#
sed(){

  case "${OSTYPE}" in
  # osx
  darwin*)
    command sed '' "$@"
    ;;
  *)
    command sed "$@"
    ;;
  esac
}

dump_apis() {
  # don't echo any thing in the function
  type=$1
  file=$2
  apis=$(grep -P 'export interface \w+ApiInterface' "$2" |
    awk '{print($3)}' |
    sed 's/Interface//')

  echo $apis
}

#
mgrApis=$(dump_apis "management" "src/api/management/api.ts")
featApis=$(dump_apis "feature" "src/api/feature/api.ts")

#
file="src/api/Apis.ts"
cp Apis.tpl $file

mgrApisImport=""
mgrApisTypes=""
mgrApisDeclarations=""
mCount=0
echo ""
echo "management apis:"
for api in $mgrApis; do
  echo $api

  field=$(echo $api | sed s/Api// | sed s/Mgr//)
  # comvert to camel
  field=${field,}

  mgrApisImport="${mgrApisImport} $api,"
  mgrApisTypes="${mgrApisTypes} ${field}:$api;"
  mgrApisDeclarations="${mgrApisDeclarations} ${field}:new $api(config, basePath, axiosInstance),"
  mCount=$((mCount + 1))
done

featApisImport=""
featApisTypes=""
featApisDeclarations=""
fCount=0
echo ""
echo "featture apis:"
for api in $featApis; do

  echo $api
  field=$(echo $api | sed s/Api// | sed s/Mgr//)

  featApisImport="${featApisImport} $api,"
  featApisTypes="${featApisTypes} ${field,}:$api;"
  featApisDeclarations="${featApisDeclarations} ${field,}:new $api(config, basePath, axiosInstance),"
  fCount=$((fCount + 1))
done
echo "Total apis, management: ${mCount},  feature: ${fCount}"

# replace codes in template
sed -i "s/\$.mgrApis/${mgrApisImport}/g" $file
sed -i "s/\$.mgrApiTypes/${mgrApisTypes}/g" $file
sed -i "s/\$.mgrApiDeclaration/${mgrApisDeclarations}/g" $file

sed -i "s/\$.featApis/${featApisImport}/g" $file
sed -i "s/\$.featApiTypes/${featApisTypes}/g" $file
sed -i "s/\$.featApiDeclaration/${featApisDeclarations}/g" $file
