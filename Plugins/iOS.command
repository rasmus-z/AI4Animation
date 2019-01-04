#!/bin/sh

default_iphoneos_version=11.0
default_architecture=arm64

export IPHONEOS_DEPLOYMENT_TARGET="${IPHONEOS_DEPLOYMENT_TARGET:-$default_iphoneos_version}"
DEFAULT_ARCHITECTURE="${DEFAULT_ARCHITECTURE:-$default_architecture}"

arch="${DEFAULT_ARCHITECTURE}"
platform=iphoneos
extra_cflags=" "

if [ $arch = "arm64" ]
    then
    host="arm-apple-darwin"
else
    host="${arch}-apple-darwin"
    extra_cflags="${extra_cflags} -DHAVE_LONG_LONG"
fi

platform_dir=`xcrun -find -sdk ${platform} --show-sdk-platform-path`
platform_sdk_dir=`xcrun -find -sdk ${platform} --show-sdk-path`
prefix="${prefix}/${arch}/${platform}${IPHONEOS_DEPLOYMENT_TARGET}.sdk"

#setup compiler flags
export CC=`xcrun -find -sdk iphoneos gcc`
export CFLAGS="-Wall -arch ${arch} -pipe -O2 -gdwarf-2 -isysroot ${platform_sdk_dir} ${extra_cflags}"
export LDFLAGS="-arch ${arch} -isysroot ${platform_sdk_dir}"
export CXX=`xcrun -find -sdk iphoneos g++`
export CXXFLAGS="${CFLAGS}"
export CPP=`xcrun -find -sdk iphoneos cpp`
export CXXCPP="${CPP}"
export AR=`xcrun -find -sdk iphoneos ar`
export RANLIB=`xcrun -find -sdk iphoneos ranlib`

cd `dirname $0`

${CXX} ${CXXFLAGS} -c -I. Eigen.cpp -o Eigen.o
${AR} -rcs libEigen.a Eigen.o
${RANLIB} libEigen.a

