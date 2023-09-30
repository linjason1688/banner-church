#!/bin/bash
find . -type f -regextype egrep -regex ".*\.(cs|sh)" \
  -not -path "*/obj/*" \
  -not -path "./.*" \
  -exec dos2unix {} \;
