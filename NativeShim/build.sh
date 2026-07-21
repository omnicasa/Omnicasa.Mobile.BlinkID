#!/bin/bash
# Builds OmnBlinkIDShim.xcframework into ../NativeLib.
# BlinkID 8 for iOS is pure Swift with no ObjC surface, so .NET cannot bind it
# directly — this shim is the bindable seam. Re-run after changing Sources/.
set -euo pipefail

cd "$(dirname "$0")"
BUILD=$(mktemp -d)
trap 'rm -rf "$BUILD"' EXIT

xcodegen generate

for sdk in iphoneos iphonesimulator; do
  xcodebuild archive \
    -project OmnBlinkIDShim.xcodeproj \
    -scheme OmnBlinkIDShim \
    -configuration Release \
    -destination "generic/platform=$([ "$sdk" = iphoneos ] && echo iOS || echo 'iOS Simulator')" \
    -archivePath "$BUILD/$sdk.xcarchive" \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
    CODE_SIGNING_ALLOWED=NO \
    >/dev/null
done

rm -rf ../NativeLib/OmnBlinkIDShim.xcframework
xcodebuild -create-xcframework \
  -framework "$BUILD/iphoneos.xcarchive/Products/Library/Frameworks/OmnBlinkIDShim.framework" \
  -framework "$BUILD/iphonesimulator.xcarchive/Products/Library/Frameworks/OmnBlinkIDShim.framework" \
  -output ../NativeLib/OmnBlinkIDShim.xcframework

echo "Built NativeLib/OmnBlinkIDShim.xcframework"
