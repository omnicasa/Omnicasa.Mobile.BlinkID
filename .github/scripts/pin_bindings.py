"""Pin Shared.Maui's binding PackageReferences to the newest published build
of the same major, so the shared package never ships against stale bindings."""
import json
import os
import re
import sys
import urllib.request

CSPROJ = "Omnicasa.Mobile.BlinkID.Shared.Maui/Omnicasa.Mobile.BlinkID.Shared.Maui.csproj"
PACKAGES = [
    "Omnicasa.Mobile.BlinkID.UX.Maui.Droid",
    "Omnicasa.Mobile.BlinkID.Maui.iOS",
]

major = os.environ["VERSION"].split(".")[0]
source = open(CSPROJ).read()

for package in PACKAGES:
    url = f"https://api.nuget.org/v3-flatcontainer/{package.lower()}/index.json"
    versions = json.load(urllib.request.urlopen(url))["versions"]
    candidates = [v for v in versions if v.split(".")[0] == major]
    if not candidates:
        sys.exit(f"::error::no published {package} with major {major}")
    latest = candidates[-1]

    source, count = re.subn(
        rf'(Include="{re.escape(package)}"\s+Version=")[^"]*"',
        rf'\g<1>{latest}"',
        source,
    )
    if count != 1:
        sys.exit(f"::error::expected 1 PackageReference for {package}, found {count}")
    print(f"{package} -> {latest}")

open(CSPROJ, "w").write(source)
