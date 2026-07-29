package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Especialidad;
import com.utp.sistemas.services.EspecialidadService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/especialidades")
public class EspecialidadController {

    @Autowired
    private EspecialidadService especialidadService;

    @PostMapping
    public Especialidad createEspecialidad(@RequestBody Especialidad especialidad) {
        return especialidadService.createEspecialidad(especialidad);
    }

    @GetMapping
    public List<Especialidad> getAllEspecialidades() {
        return especialidadService.getAllEspecialidades();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Especialidad> getEspecialidadById(@PathVariable Integer id) {
        return especialidadService.getEspecialidadById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Especialidad> updateEspecialidad(@PathVariable Integer id, @RequestBody Especialidad especialidadDetails) {
        Especialidad updatedEspecialidad = especialidadService.updateEspecialidad(id, especialidadDetails);
        return updatedEspecialidad != null ? ResponseEntity.ok(updatedEspecialidad) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteEspecialidad(@PathVariable Integer id) {
        especialidadService.deleteEspecialidad(id);
        return ResponseEntity.noContent().build();
    }
}