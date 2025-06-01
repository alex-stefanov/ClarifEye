document.addEventListener('DOMContentLoaded', function () {
    const dropdownEl = document.querySelector('#dropdown');
    dropdownEl.addEventListener('change', function () {
        const value = dropdownEl.value;
        console.log(value);

        fetch(`/Statistics/FetchData?question=${encodeURIComponent(value)}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                return response.json();
            })
            .then(data => {
                const formattedData = Object.entries(data).map(([key, value]) => ({
                    name: key,
                    value: value
                }));

                console.log(formattedData)

                const width = 600; // you need to define this
                const height = Math.min(width, 500);
                const radius = Math.min(width, height) / 2;

                const arc = d3.arc()
                    .innerRadius(radius * 0.67)
                    .outerRadius(radius - 1);

                const pie = d3.pie()
                    .padAngle(1 / radius)
                    .sort(null)
                    .value(d => d.value);

                const color = d3.scaleOrdinal()
                    .domain(formattedData.map(d => d.name))
                    .range(d3.quantize(t => d3.interpolateSpectral(t * 0.8 + 0.1), formattedData.length).reverse());

                const svg = d3.create("svg")
                    .attr("width", width)
                    .attr("height", height)
                    .attr("viewBox", [-width / 2, -height / 2, width, height])
                    .attr("style", "max-width: 100%; height: auto;");

                svg.append("g")
                    .selectAll()
                    .data(pie(formattedData))
                    .join("path")
                    .attr("fill", d => color(d.data.name))
                    .attr("d", arc)
                    .append("title")
                    .text(d => `${d.data.name}: ${d.data.value.toLocaleString()}`);

                svg.append("g")
                    .attr("font-family", "sans-serif")
                    .attr("font-size", 12)
                    .attr("text-anchor", "middle")
                    .selectAll()
                    .data(pie(formattedData))
                    .join("text")
                    .attr("transform", d => `translate(${arc.centroid(d)})`)
                    .call(text => text.append("tspan")
                        .attr("y", "-0.4em")
                        .attr("font-weight", "bold")
                        .text(d => d.data.name))
                    .call(text => text.filter(d => (d.endAngle - d.startAngle) > 0.25).append("tspan")
                        .attr("x", 0)
                        .attr("y", "0.7em")
                        .attr("fill-opacity", 0.7)
                        .text(d => d.data.value.toLocaleString("en-US")));

                document.querySelector("#result").appendChild(svg.node());
            });

    });
});