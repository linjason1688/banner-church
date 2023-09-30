#!/bin/sh

target=$1
testCategories=""

# use
#testCategories="TestCategory=TestFeatureACategory"

#  --collect "Code Coverage" \

case ${target} in
ldap)
  #
  testCategories="TestCategory=TestLdap"
  ;;
vmw)
  #
  testCategories="TestCategory=TestVmware"
  ;;
env)
  #
  testCategories="TestCategory=TestEnvelope"
  ;;
cust)
  #
  testCategories="TestCategory=TestCustDependency"
  ;;
smtp)
  #
  testCategories="TestCategory=TestSmtp"
  ;;
*)
  echo "use default categories"
  testCategories="TestCategory=TestBaseCategory|TestCategory=TestBusinessLogicCategory"
  ;;
esac

dotnet test App.Dependency.Test/App.Dependency.Test.csproj \
  --filter "${testCategories}" \
  -r TestResults 2>&1 | tee TestResults/Test.out.log
