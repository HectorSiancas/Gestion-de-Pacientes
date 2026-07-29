package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Empleado;
import com.utp.sistemas.services.EmpleadoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/empleados")
public class EmpleadoController {

    @Autowired
    private EmpleadoService empleadoService;

    @PostMapping
    public Empleado createEmpleado(@RequestBody Empleado empleado) {
        return empleadoService.createEmpleado(empleado);
    }

    @GetMapping
    public List<Empleado> getAllEmpleados() {
        return empleadoService.getAllEmpleados();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Empleado> getEmpleadoById(@PathVariable Integer id) {
        return empleadoService.getEmpleadoById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Empleado> updateEmpleado(@PathVariable Integer id, @RequestBody Empleado empleadoDetails) {
        Empleado updatedEmpleado = empleadoService.updateEmpleado(id, empleadoDetails);
        return updatedEmpleado != null ? ResponseEntity.ok(updatedEmpleado) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteEmpleado(@PathVariable Integer id) {
        empleadoService.deleteEmpleado(id);
        return ResponseEntity.noContent().build();
    }
}